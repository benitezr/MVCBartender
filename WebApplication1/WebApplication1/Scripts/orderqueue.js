var url = '/Home/QueueList';
$('#queue').on('click', '.complete', function () {
    var orderID = $(this).attr('id');
    $('#queue').load(url, { id: orderID });
});