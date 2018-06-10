define([], function () {
    return function (template) {
        return {
            template: template,
            data: function () {
                return {
                    searchResult: {}
                }
            }
        };
    };
});