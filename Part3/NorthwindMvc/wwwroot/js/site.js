// Write your JavaScript code.


$(".clickTohref").click(function(){
    $(location).attr("href", $(this).attr("href"));
});