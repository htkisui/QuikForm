﻿$(function () {

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