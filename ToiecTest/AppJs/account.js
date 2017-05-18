var account = function () {
    return {
        init: function () {
            this.pageIndex = 1;
            this.FirstLoad = true;
            this.loadData(this.pageIndex);
        },
        loadData: function (pageindex) {
            var self = this;
            if (this.FirstLoad);
        }

    }

}();
$(function () { account.init(); });