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

    // Create Question
    $("#create-question").on("click", (e) => {
        $.post("/Question/Create", (data) => {
            $("#question-form-list").append(data)
        });
    });

    // Create Field
    $(document).on("click", ".create-field-button", function (e) {
        const fieldContainer = $(this).data("target-list");
        const targetList = $("#" + fieldContainer);

        const questionIdArray = fieldContainer.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Field/Create", { questionId : questionIdPart } , (data) => {
            targetList.append(data);
        });
    });

    // Delete Field
    $(document).on("click", ".delete-field-button", function (e) {
        const field = $(this).data("target-field");
        const targetField = $("#" + field);
      
        const fieldIdArray = field.split('-');
        const fieldIdPart = fieldIdArray.slice(-1);

        $.post("/Field/Delete", { id: fieldIdPart }, () => {
            targetField.remove();
        });
    });

    // Update Field
    $(document).on("focusout", ".field-label", function (e) {
        const field = $(this).data("target-field");

        const fieldIdArray = field.split('-');
        const fieldIdPart = fieldIdArray.slice(-1);

        $.post("/Field/Update", { id: fieldIdPart, label: $(this).val() }, () => { });
    })
});