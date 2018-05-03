$( document ).ready(function() {
    $('#loginBody').hide();
    $('#login').hide();
    $('#register').hide();

    $('#loginDiv').click(function(){
        $('#page').hide();
        $('#loginBody').show();
        $('#login').show();
        $('#register').hide();
        $('.footer.push').hide();
    });

    $('#signin').click(function() {
        $('#page').hide();
        $('#loginBody').show();
        $('#login').show();
        $('#register').hide();
        $('.footer.push').hide();
    });

    $('#create').click(function() {
        $('#page').hide();
        $('#loginBody').show();
        $('#login').hide();
        $('#register').show();
        $('.footer.push').hide();
    });

    $('.close').click(function() {
        $('#loginBody').hide();
        $('#login').hide();
        $('#register').hide();
        $('#page').show();
        $('.footer.push').show();
    });
});
