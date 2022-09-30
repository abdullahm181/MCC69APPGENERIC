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
function confirmDelete(IdDataTable, ControllerName, IdData = null) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
    }).then(result => {
        if (result.dismiss) {
            swal("Cancelled", "Your imaginary file is safe :)", "error");
        }
        if (result.value) {
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

        }
        /*
        swal("Deleted!", "Your file has been deleted.", "success");
        if (result.value) {
            $(".post-list")
                .find(".select-input:checked")
                .closest(".item")
                .remove();
        } else if (
            // Read more about handling dismissals
            result.dismiss === swal.DismissReason.cancel
        ) {
            swal("Cancelled", "Your imaginary file is safe :)", "error");
        }*/
        //swall.closeModal();
    });
};
/*module.exports = {
    GetAll: GetAll
};*/