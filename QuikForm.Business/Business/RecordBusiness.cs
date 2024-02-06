using QuikForm.Business.Contracts.Business;
using QuikForm.Business.Contracts.Exceptions.FieldRecords;
using QuikForm.Business.Contracts.Exceptions.Fields;
using QuikForm.Business.Contracts.Exceptions.Questions;
using QuikForm.Entities;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.Repository.Contracts.Exceptions.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Business.Business;
public class RecordBusiness : IRecordBusiness
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IFieldRecordRepository _fieldRecordRepository;
    private readonly IRecordRepository _recordRepository;

    public RecordBusiness(IQuestionRepository questionRepository, IFieldRecordRepository fieldRecordRepository, IRecordRepository recordRepository)
    {
        _questionRepository = questionRepository;
        _fieldRecordRepository = fieldRecordRepository;
        _recordRepository = recordRepository;
    }

    public async Task CreateAsync(Dictionary<string, string> records)
    {
        Record record = new Record();
        await _recordRepository.CreateAsync(record);

        foreach (KeyValuePair<string, string> recordKeyValuePair in records)
        {
            int fieldId = 0;
            if (!recordKeyValuePair.Key.Contains("-")) throw new FieldRecordInvalidFormatException();
            string inputType = recordKeyValuePair.Key.Split("-")[0];
            if (inputType == "radio")
            {
                // recordKeyValuePair.Key = Question ID
                int questionId = int.TryParse(recordKeyValuePair.Key.Split("-")[1], out int _questionId) ? _questionId : throw new QuestionInvalidIdFormatException();
                try
                {
                    Question question = await _questionRepository.GetByIdAsync(questionId);
                    foreach (Field field in question.Fields)
                    {
                        if (field.Label == recordKeyValuePair.Value)
                        {
                            fieldId = field.Id;
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                if (fieldId == 0) throw new FieldNotFoundException();
            }
            else
            {
                // recordKeyValuePair.Key = Field ID
                fieldId = int.TryParse(recordKeyValuePair.Key.Split("-")[1], out int _fieldId) ? _fieldId : throw new FieldInvalidIdFormatException();
            }
            FieldRecord fieldRecord = new FieldRecord() { FieldId = fieldId, RecordId = record.Id, CustomAnswer = recordKeyValuePair.Value };
            await _fieldRecordRepository.CreateAsync(fieldRecord);
        }
    }
}
