$(function () {
    // Form Title Update
    $(document).on("focusout", "#title-content", function (e) {
        const form = $(this).data("target-form");

        const formIdArray = form.split('-');
        const formIdPart = formIdArray.slice(-1);

        $.post("/Form/UpdateTitle", { id: formIdPart, title: $(this).val() }, () => { });
    })

    // Form Description Update
    $(document).on("focusout", "#description-content", function (e) {
        const form = $(this).data("target-form");

        const formIdArray = form.split('-');
        const formIdPart = formIdArray.slice(-1);

        $.post("/Form/UpdateDescription", { id: formIdPart, description: $(this).val() }, () => { });
    })

    // Question : Create
    $(document).on("click", ".create-question-button", function (e) {
        const questionContainer = $(this).data("target-list");
        const targetList = $("#" + questionContainer);

        const formIdArray = questionContainer.split("-");
        const questionIdPart = formIdArray.slice(-1);

        $.post("/Question/Create", { formId: questionIdPart }, (data) => {
            targetList.append(data);
        });
    });

    // Question : Delete 
    $(document).on("click", ".delete-question-button", function (e) {
        const question = $(this).data("target-question");
        const targetQuestion = $("#" + question);

        const questionIdArray = question.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Question/Delete", { id: questionIdPart }, () => {
            targetQuestion.remove();
        });
    });

    // Question : UpdateLabel
    $(document).on("focusout", ".question-label", function (e) {
        const question = $(this).data("target-question");
        const label = $(this).val();

        const questionIdArray = question.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Question/UpdateLabel", { id: questionIdPart, label: label }, () => { });
    })

    // Question : UpdateInputType
    $(document).on("change", ".question-type-select", function (e) {
        const question = $(this).data("target-question");
        const inputTypeMarkup = $(this).val();


        const questionIdArray = question.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        const fieldFormList = $("#field-form-list-" + questionIdPart);

        $.post("/Question/UpdateInputType", { id: questionIdPart, inputTypeMarkup: inputTypeMarkup }, () => { });
        $.post("/Question/DeleteFields", { id: questionIdPart }, (data) => { fieldFormList.remove() });
    })


    // Question : UpdateIsMandatory
    $(document).on("change", ".question-IsMandatory", function (e) {
        const question = $(this).data("target-question");
        const isMandatory = $(this).is(':checked');

        const questionIdArray = question.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Question/UpdateIsMandatory", { id: questionIdPart, isMandatory: isMandatory }, () => { });
    })

    // Field : Create 
    $(document).on("click", ".create-field-button", function (e) {
        const fieldContainer = $(this).data("target-list");
        const targetList = $("#" + fieldContainer);

        const questionIdArray = fieldContainer.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Field/Create", { questionId: questionIdPart }, (data) => {
            targetList.append(data);
        });
    });

    // Field : Delete 
    $(document).on("click", ".delete-field-button", function (e) {
        const field = $(this).data("target-field");
        const targetField = $("#" + field);

        const fieldIdArray = field.split('-');
        const fieldIdPart = fieldIdArray.slice(-1);

        $.post("/Field/Delete", { id: fieldIdPart }, () => {
            targetField.remove();
        });
    });

    // Field : Update 
    $(document).on("focusout", ".field-label", function (e) {
        const field = $(this).data("target-field");

        const fieldIdArray = field.split('-');
        const fieldIdPart = fieldIdArray.slice(-1);

        $.post("/Field/Update", { id: fieldIdPart, label: $(this).val() }, () => { });
    })
});