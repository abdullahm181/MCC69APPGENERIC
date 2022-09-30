//GET
const GetAll = (ControllerName, BodyData = null) => $.ajax({
    type: 'GET',
    url: `/${ControllerName}/GetAll`,
    data: BodyData ? BodyData : null,
}).done(result => {

}).fail((error) => {
    console.log(error);
});

const Get = (ControllerName, BodyData = null) => $.ajax({
    type: 'GET',
    url: `/${ControllerName}/Get`,
    data: BodyData ? BodyData : null,
}).done(result => {

}).fail((error) => {
    console.log(error);
});

const Put = (ControllerName, BodyData = null) => $.ajax({
    type: 'PUT',
    url: `/${ControllerName}/Put`,
    data: BodyData ? BodyData : null,
}).done(result => {
    console.log(result);
}).fail((error) => {
    console.log(error);
});


const Post = (ControllerName, BodyData = null) => $.ajax({
    type: 'POST',
    url: `/${ControllerName}/Post`,
    data: BodyData ? BodyData : null,
}).done(result => {

}).fail((error) => {
    console.log(error);
});

const DeleteEntity = (ControllerName, BodyData = null) => $.ajax({
    type: 'DELETE',
    url: `/${ControllerName}/DeleteEntity`,
    data: BodyData ? BodyData : null,
}).done(result => {

}).fail((error) => {
    console.log(error);
});


const PutOptions = (IdSelec, Object, SelectedId) => {
    $(`#${IdSelec}`).empty()
    $.each(Object, function () {
        if (this.id == SelectedId) {
            $(`#${IdSelec}`).append(`<option value="${this.id}" selected="selected">${this.jobTitle}</option>`);
        }
        else {
            $(`#${IdSelec}`).append($("<option />").val(this.id).text(this.jobTitle));
        }

    });
};
function confirmDelete(IdDataTable,ControllerName, IdData = null) {
    swal({
        title: 'Are you sure?',
        text: "It will permanently deleted !",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then(function (isConfirm) {
        if (!isConfirm) return;
        $.ajax({
            type: 'DELETE',
            url: `/${ControllerName}/DeleteEntity`,
            data: {
                id: IdData
            },
            success: function () {
                $(`#${IdDataTable}`).DataTable().ajax.reload();
                swal("Done!", "It was succesfully deleted!", "success");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                swal("Error deleting!", "Please try again", "error");
            }
        });
    });
}
/*module.exports = {
    GetAll: GetAll
};*/