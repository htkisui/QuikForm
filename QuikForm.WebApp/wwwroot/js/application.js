﻿$(function () {
    // Admin Dashboard Search
    $(document).on("keyup", "#dashboard-search", function (e) {
        const title = $(this).val();
        const token = $("#token input:first").val();

        $.post("Admin/Search", { title: title, __RequestVerificationToken: token }, (data) => {
            const table = $(".form-table-vc");
            const mainCntainer = $("#main-container");
            table.remove();
            mainCntainer.append(data);
        });
    });

    // Form Title Update
    $(document).on("focusout", "#title-content", function (e) {
        const form = $(this).data("target-form");
        const token = $("#token input:first").val();

        const formIdArray = form.split('-');
        const formIdPart = formIdArray.slice(-1);

        $.post("/Form/UpdateTitle", { id: formIdPart, title: $(this).val(), __RequestVerificationToken: token }, () => { });
    })

    // Form Description Update
    $(document).on("focusout", "#description-content", function (e) {
        const form = $(this).data("target-form");
        const token = $("#token input:first").val();

        const formIdArray = form.split('-');
        const formIdPart = formIdArray.slice(-1);

        $.post("/Form/UpdateDescription", { id: formIdPart, description: $(this).val(), __RequestVerificationToken: token }, () => { });
    })

    // Question : Create
    $(document).on("click", ".create-question-button", function (e) {
        const questionContainer = $(this).data("target-list");
        const targetList = $("#" + questionContainer);
        const token = $("#token input:first").val();

        const formIdArray = questionContainer.split("-");
        const questionIdPart = formIdArray.slice(-1);

        $.post("/Question/Create", { formId: questionIdPart, __RequestVerificationToken: token }, (data) => {
            targetList.append(data);
        });
    });

    // Question : Delete 
    $(document).on("click", ".delete-question-button", function (e) {
        const question = $(this).data("target-question");
        const targetQuestion = $("#" + question);
        const token = $("#token input:first").val();

        const questionIdArray = question.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Question/Delete", { id: questionIdPart, __RequestVerificationToken: token }, () => {
            targetQuestion.remove();
        });
    });

    // Question : UpdateLabel
    $(document).on("focusout", ".question-label", function (e) {
        const question = $(this).data("target-question");
        const label = $(this).val();
        const token = $("#token input:first").val();

        const questionIdArray = question.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Question/UpdateLabel", { id: questionIdPart, label: label, __RequestVerificationToken: token }, () => { });
    });

    // Question : UpdateInputType
    $(document).on("change", "#question-type", async function (e) {
        const question = $(this).data("target-question");
        const inputTypeMarkup = $(this).val();
        const token = $("#token input:first").val();

        const questionIdArray = question.split('-');
        const questionIdPart = questionIdArray.slice(-1);
        const fieldFormList = $("#field-form-list-" + questionIdPart);

        await $.post("/Question/DeleteFields", { id: questionIdPart, __RequestVerificationToken: token }, () => {
            fieldFormList.empty();
        });
        await $.post("/Question/UpdateInputType", { id: questionIdPart, inputTypeMarkup: inputTypeMarkup, __RequestVerificationToken: token }, (data) => {
            const fieldFormListVC = $("#field-form-list-vc-" + questionIdPart);
            const fieldAddButtonVC = $("#field-add-button-vc-" + questionIdPart);
            if (data === "text" || data === "textarea") {
                $.post("/Field/Create", { questionId: questionIdPart, __RequestVerificationToken: token }, (data) => {
                    fieldFormList.append(data);
                    fieldAddButtonVC.remove();
                });
            } else {
                if (fieldFormList.children().length == 0 && fieldFormListVC.children().length < 2) {
                    $.post("/Field/GetAddButton", { questionId: questionIdPart }, (data) => {
                        fieldFormListVC.append(data);
                    });
                }
            }
        });
    });

    // Question : UpdateIsMandatory
    $(document).on("change", ".question-IsMandatory", function (e) {
        const question = $(this).data("target-question");
        const isMandatory = $(this).is(':checked');
        const token = $("#token input:first").val();

        const questionIdArray = question.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Question/UpdateIsMandatory", { id: questionIdPart, isMandatory: isMandatory, __RequestVerificationToken: token }, () => { });
    })

    // Field : Create 
    $(document).on("click", ".field-add-button-vc", function (e) {
        const fieldContainer = $(this).data("target-list");
        const targetList = $("#" + fieldContainer);
        const token = $("#token input:first").val();

        const questionIdArray = fieldContainer.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Field/Create", { questionId: questionIdPart, __RequestVerificationToken: token }, (data) => {
            targetList.append(data);
        });
    });

    // Field : Delete 
    $(document).on("click", ".delete-field-button", function (e) {
        const field = $(this).data("target-field");
        const targetField = $("#" + field);
        const token = $("#token input:first").val();

        const fieldIdArray = field.split('-');
        const fieldIdPart = fieldIdArray.slice(-1);

        $.post("/Field/Delete", { id: fieldIdPart, __RequestVerificationToken: token }, () => {
            targetField.remove();
        });
    });

    // Field : Update 
    $(document).on("focusout", ".field-label", function (e) {
        const field = $(this).data("target-field");
        const token = $("#token input:first").val();

        const fieldIdArray = field.split('-');
        const fieldIdPart = fieldIdArray.slice(-1);

        $.post("/Field/Update", { id: fieldIdPart, label: $(this).val(), __RequestVerificationToken: token }, () => { });
    })
});