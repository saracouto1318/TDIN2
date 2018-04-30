$( document ).ready(function() {
    $('#editProfile').hide();
    $('#myTickets').hide();
    $('#newTickets').hide();

    $('#edit').click(function(){
        $('#editProfile').show();
        $('#newTickets').hide();
        $('#myTickets').hide();
    });

    $('#my').click(function(){
        $('#editProfile').hide();
        $('#newTickets').hide();
        $('#myTickets').show();
    });

    $('#new').click(function() {
        $('#editProfile').hide();
        $('#newTickets').show();
        $('#myTickets').hide();
    });
});
