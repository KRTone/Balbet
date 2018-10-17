function getUsersJson(skip, take) {
    skip = skip || 0;
    take = take || 5;
    return $.ajax({
        url: 'api/userpaging',
        dataType: 'json',
        processData: false,
        contentType: 'application/json',
        data: JSON.stringify({ skip: skip, take: take }),
        type: "POST",
        success: function (responce) {
            responce;
        }
    });
}