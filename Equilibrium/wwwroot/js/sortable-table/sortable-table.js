Equilibrium.SortableTable = {
    init: function (options) {
        let target = options.target;
        console.log(target);
    },
    filter: function () {
        console.log(this.target.data());
    },
};

class SortableTable {
    #options;

    constructor(options) {
        this.#options = options;
    };

    options() {
        return this.#options;
    };
}