function handleListAjaxSuccess(data) {
    $('#company-list').html(data);
}

function handleFilterButtonClick(url, pageSize) {
    filterPage(url, pageSize);
}

function handleClearButtonClick(actionUrl, pageSize) {
    $.ajax({
        url: actionUrl,
        method: "GET",
        data: { size: pageSize },
        success: handleListAjaxSuccess,
        cache: false
    });
    $("#name-search-input").val("");
}

function filterPage(actionUrl, pageSize) {
    var nameSearchInput = $("#name-search-input").val();

    $.ajax({
        url: actionUrl,
        method: "GET",
        data: {
            size: pageSize,
            NameSearch: nameSearchInput
        },
        success: handleListAjaxSuccess,
        cache: false
    });
}