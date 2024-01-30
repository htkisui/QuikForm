$(function () {

    // Create Question
    $("#create-question").on("click", (e) => {
        $.post("/Question/Create", (data) => {
            $("#question-form-list").append(data)
        });
    });

    // Create Field
    $(".create-field-button").on("click", function (e) {
        var questionId = $(this).data("target-list");
        var targetList = $("#" + questionId);
        $.post("/Field/Create", (data) => {
            targetList.append(data);
        });
    });

});