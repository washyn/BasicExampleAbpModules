$(function () {
    var l = abp.localization.getResource('webApplicationMvc');
    
    var dataTable = $('#exampleTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            // order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(webApplicationMvc.controllers.apiDetail.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        // editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    action: function (data) {
                                        // editModal.open({ id: data.record.id });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: 'Cadena',
                    data: "cadena"
                },
                {
                    title: 'Booleano',
                    data: "booleano",
                    render: function (data) {
                        return abp.libs.datatables.defaultRenderers.boolean(data);
                    }
                },
                {
                    title: 'Decimal',
                    data: "decimanl"
                },
                {
                    title: 'Entero',
                    data: "entero"
                },
                // {
                //     title: l('Name'),
                //     data: "name"
                // },
                // {
                //     title: l('Type'),
                //     data: "type",
                //     render: function (data) {
                //         return l('Enum:BookType:' + data);
                //     }
                // },
                // {
                //     title: l('PublishDate'),
                //     data: "publishDate",
                //     render: function (data) {
                //         return luxon
                //             .DateTime
                //             .fromISO(data, {
                //                 locale: abp.localization.currentCulture.name
                //             }).toLocaleString();
                //     }
                // },

                // {
                //     title: l('CreationTime'), data: "creationTime",
                //     render: function (data) {
                //         return luxon
                //             .DateTime
                //             .fromISO(data, {
                //                 locale: abp.localization.currentCulture.name
                //             }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                //     }
                // }
            ]
        })
    );
    //
    // var createModal = new abp.ModalManager(abp.appPath + 'Books/CreateModal');
    //
    // createModal.onResult(function () {
    //     dataTable.ajax.reload();
    // });
    //
    // $('#NewBookButton').click(function (e) {
    //     e.preventDefault();
    //     createModal.open();
    // });
});