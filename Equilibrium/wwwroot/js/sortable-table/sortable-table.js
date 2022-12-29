Equilibrium.SortableTable = {
    init: function (options) {
        this.target = new SortableTable(options)
    },
    filter: function () {
        console.log(this.target.source());
    },
};

class SortableTable {
    #source;

    constructor(source) {
        this.#source = source;
    };

    source() {
        return this.#source;
    };
}