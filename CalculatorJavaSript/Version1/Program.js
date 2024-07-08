const calculator = {
    Add: function () {
        let result = arguments[0];

        for (var i = 1; i < arguments.length; i++) {
            result += arguments[i];
        }

        return result;
    },
    Subtract: function () {
        let result = arguments[0];

        for (var i = 1; i < arguments.length; i++) {
            result -= arguments[i];
        }

        return result;
    },
    Multiply: function () {
        let result = arguments[0];

        for (var i = 1; i < arguments.length; i++) {
            result /= arguments[i];
        }

        return result;
    },
    Divide: function () {
        let result = arguments[0];

        for (var i = 1; i < arguments.length; i++) {
            result /= arguments[i];
        }

        return result;
    }
}

module.exports = calculator