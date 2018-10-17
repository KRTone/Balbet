$(function () {
    jQuery.validator.unobtrusive.adapters.add('birthday', ['validage'], function (options) {
        // Set up test parameters
        var params = {
            validage: options.params.validage
        };

        // Match parameters to the method to execute
        options.rules['birthday'] = params;
        if (options.message) {
            // If there is a message, set it for the rule
            options.messages['birthday'] = options.message;
        }
    });

    jQuery.validator.addMethod("birthday", function (value, element, param) {
        if (value === "") {
            return false;
        }

        var allowableAge = Date.now();

        return filesize <= validage;
    });
}(jQuery));