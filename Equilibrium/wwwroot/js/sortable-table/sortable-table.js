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
        let declaredFilters = Array.from(root.querySelectorAll('[data-eq-sortable-filter]'));
        if (declaredFilters.length > 0) {
            this.#filterCollection = []
            declaredFilters.map(filter => {
                this.#filterCollection.push(
                    new SortableTableFilterItem(
                        filter.dataset.eqSortableFilter,
                        filter.innerText
                    )
                );
            })

            let rootParent = root.parentNode;
            Array.from(this.#filterCollection).map(filterItem => {
                let itemLabel = filterItem.htmlBare();
                rootParent.insertBefore(itemLabel, root);
            });
        };
    };

    options() {
        return this.#options;
    };
}

class SortableTableFilterItem {
    #sourcePropertyName
    #displayPropertyName
    #htmlBare

    constructor(source, display) {
        this.#sourcePropertyName = source;
        this.#displayPropertyName = display;
        const id = `eq-sortable-property-source-${source}`
        // create the label
        let label = document.createElement('label');
        label.setAttribute('for', id);
        label.innerText = display;
        // create the select (with no records yet)
        let select = document.createElement('select');
        select.setAttribute('id', id);
        select.setAttribute('name', id);
        let defaultOption = document.createElement('option');
        defaultOption.setAttribute('value', null);
        defaultOption.innerText = "All";
        select.append(defaultOption);
        // create a common container
        let div = document.createElement('div');
        div.append(label);
        div.append(select);

        this.#htmlBare = div;
    }

    sourcePropertyName() {
        return this.#sourcePropertyName;
    }

    displayPropertyName() {
        return this.#displayPropertyName;
    }

    htmlBare() {
        return this.#htmlBare;
    }
}