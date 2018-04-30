$( document ).ready(function() {
    $('#loginBody').hide();
    $('#login').hide();
    $('#register').hide();

    $('#loginDiv').click(function(){
        $('#page').hide();
        $('#loginBody').show();
        $('#login').show();
        $('#register').hide();
    });

    $('#signin').click(function() {
        $('#page').hide();
        $('#loginBody').show();
        $('#login').show();
        $('#register').hide();
    });

    $('#create').click(function() {
        $('#page').hide();
        $('#loginBody').show();
        $('#login').hide();
        $('#register').show();
    });

    $('.close').click(function() {
        $('#loginBody').hide();
        $('#login').hide();
        $('#register').hide();
        $('#page').show();
    });
});