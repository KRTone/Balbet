function createUsersTableRows(source) {
    $("table.table tr:eq(1)").hide();
    $.each(source, function (idx, obj) {
        var clone = $('[data-rows="maintable-row"]').clone().attr('data-rows', 'maintable-row-' + obj.Login);
        clone.find('[data-cel-login="maintable-row-login"]').attr('data-cel-login', 'maintable-row-login-' + obj.Login).append(obj.Login);
        clone.find('[data-cel-firstname="maintable-row-firstname"]').attr('data-cel-firstname', 'maintable-row-firstname-' + obj.FirstName).append(obj.FirstName);
        clone.find('[data-cel-lastname="maintable-row-lastname"]').attr('data-cel-lastname', 'maintable-row-lastname-' + obj.LastName).append(obj.LastName);
        clone.find('[data-cel-passport="maintable-row-passport"]')
            .attr('data-cel-passport', 'maintable-row-passport-' + obj.Passport.Seria + obj.Passport.Code)
            .append(obj.Passport.Seria +" "+ obj.Passport.Code);
        $('table.table').append(clone.show("fast"));
    });
}

function usersLoadMoreButtonHide(source, take, button) {
    if (source.length < take) {
        button.hide();
    }
}

function showLoadMoreUsers() {
    var mainTable = $('[data-name="mainTable"]');
    var loadMoreButton = $('[data-name="loadMoreButton"]');
    var skippedUsers = parseInt(mainTable.data('skipped'));
    var numfOfUsers = parseInt(mainTable.data('skip'));
    if (isLoadMore) {
        getUsersJson(skippedUsers, numfOfUsers)
            .then(function (response) {
                createUsersTableRows(response);
                return response
            })
            .then(function (response) {
                usersLoadMoreButtonHide(response, numfOfUsers, loadMoreButton)
            })
            .then(function () {
                mainTable.data('skipped', skippedUsers + numfOfUsers);
            })
    };
};

var isLoadMore = true;

$(document).ajaxStart(function () {
    isLoadMore = false;
})
$(document).ajaxComplete(function () {
    isLoadMore = true;
})
function loadMoreScroll() {
    var scrollHeight = $(document).height();
    var scrollPosition = $(window).height() + $(window).scrollTop();
    if ((scrollHeight - scrollPosition) / scrollHeight <= 0.001) {
        showLoadMoreUsers();
    }
}
$(window).on('scroll', function () {
    loadMoreScroll();
});