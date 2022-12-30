Equilibrium.SortableTable.init = function (options) {
    Equilibrium.SortableTable = new SortableTable(options);
}

class SortableTable {
    /**
     * properties
     * target   : the DOM element containing the table
     * */
    #options;
    #filterCollection;

    constructor(options) {
        this.#options = options;
        const root = this.#options.target;

        // creates the filter elements
        let declaredFilters = Array.from(root.querySelectorAll('[data-eq-sortable-prop]'));
        if (declaredFilters.length > 0) {
            this.#filterCollection = []
            declaredFilters.map(filter => {
                this.#filterCollection.push(
                    new SortableTableFilterItem(
                        filter.dataset.eqSortableProp,
                        filter.innerText
                    )
                );
            })
        };
    };

    options() {
        return this.#options;
    };
}

class SortableTableFilterItem {
    #sourcePropertyName;
    #displayPropertyName;

    constructor(source, display) {
        this.#sourcePropertyName = source;
        this.#displayPropertyName = display;
    }

    sourcePropertyName() {
        return this.#sourcePropertyName;
    }

    displayPropertyName() {
        return this.#displayPropertyName;
    }
}