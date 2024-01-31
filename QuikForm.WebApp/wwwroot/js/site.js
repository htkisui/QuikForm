$(function () {

    // Create Question
    $("#create-question").on("click", (e) => {
        $.post("/Question/Create", (data) => {
            $("#question-form-list").append(data)
        });
    });

    // Create Field
    $(".create-field-button").on("click", function (e) {
        const fieldContainer = $(this).data("target-list");
        const targetList = $("#" + fieldContainer);

        let questionIdArray = fieldContainer.split('-');
        const questionIdPart = questionIdArray.slice(-1);

        $.post("/Field/Create", { questionId : questionIdPart } , (data) => {
            targetList.append(data);
        });
    });

});