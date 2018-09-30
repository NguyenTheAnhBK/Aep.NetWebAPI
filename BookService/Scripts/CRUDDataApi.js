
$(document).ready(function () {
    LoadData();
}); 
function LoadData() {
    $.ajax({
        type: "GET",
        url: "/api/books",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            var rows = '';
            $.each(data, function (i, element) {
                rows += "<tr>" + "<td>" + element.id + "</td>" +
                    "<td>" + element.title + "</td>" +
                    "<td>" + element.name + "</td>" +
                    "<td>" +
                    "<button class='btn btn-primary' onclick=" + "BookDetail(" + element.id + ")" + ">" + "Detail" + "</button>" + "&nbsp;" +
                    "<button class='btn btn-danger' onclick=" + "DeleteBook(" + element.id + ")" + ">" + "Delete" + "</button>" +
                    "</td>" +
                    "</tr>";
            });
            $('#table').html(rows);
            console.log(data);
        },
        failure: function (data) {
            alert(data.responseText());
        },
        error: function (data) {
            alert();
        }
    });
}
function BookDetail(id) {
    $('.modal-title').html('').append("Book Details");
    $('#btnSave').addClass('hide');
    $('#myModal').modal('toggle');
    $.ajax({
        type: "GET",
        url: "/api/books/" + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            var content = "<table class='table table-bordered table - hover'> <tbody>"+
                "<tr><td>Id</td> <td>" + data.id + "</td> </tr>" +
                "<tr><td>Title</td> <td>" + data.title + "</td> </tr> " +
                "<tr><td>Publish date</td> <td>" + data.year + "</td> </tr>" +
                "<tr><td>Genreration</td> <td>" + data.genre + "</td> </tr>" +
                "<tr><td>Author</td> <td>" + data.authorName + "</td> </tr>" +
                "<tr><td>Price</td> <td>" + "$" + data.price + "</td> </tr>" +
                "</tbody></table>";
            $('.modal-body').html('').append(content);
            console.log(data);
        },
        failure: function (data) {
            alert(data.responseText());
        },
        error: function (data) {
            alert(data.responseText());
        }
    });
}
function DeleteBook(id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            type: "DELETE",
            url: "/api/books/" + id,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                LoadData();
            },
            failure: function (result) {
                alert(result.responseText());
            },
            error: function (err) {
                alert(err.responseText());
            }
        });
    }
}
function ModalForm() {
    $('.modal-title').html('').append("New book");
    var form = $('#form').html();
    $('.modal-body').html(form);
    $('#btnSave').removeClass('hide');
    $.ajax({
        type: "GET",
        url: "/api/authors",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var opt = '';
            $.each(data, function (i, element) {
                opt += "<option value=" + element.id + ">" + element.name + "</option>"
            });
            $('#optId').html(opt);
        },
        error: function (err) {
            alert(err.responseText());
        }
    });
    $('#myModal').modal('show');
}
function AddBook() {
    //var x = FindAuthor("sd");
    //alert(x);
    var res = ValidateBook();
    if (res == false) {
        return false;
    };
    var bookObj = {
        title: $('#title').val(),
        year: $('#year').val(),
        genre: $('#genre').val(),
        authorId: $('#authorId').val(),
        price: $('#price').val(),
    };

    $.ajax({
        type: "POST",
        url: "/api/books",
        data: JSON.stringify(bookObj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadData();
            $('#myModal').modal('hide');
        },
        failure: function (result) {
            alert(result.responseText());
        },
        error: function (err) {
            alert(err.responseText());
        }
    })
}
function ValidateBook() {
    var isValid = true;
    if ($('#title').val().trim() == "") {
        $('#title').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#title').css('border-color', 'lightgrey');
    }  
    if ($('#year').val().trim() == "") {
        $('#year').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#year').css('border-color', 'lightgrey');
    }  
    if ($('#genre').val().trim() == "") {
        $('#genre').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#genre').css('border-color', 'lightgrey');
    }  
    if ($('#authorId').val().trim() == "") {      
        if ($('#formAuthor').hasClass()) {
            if ($('#formAuthor').val().trim() == "") {
                $('#authorId').css('border-color', 'lightgrey');
                $('#name').css('border-color', 'Red');
                isValid = false;
            }
            else
                $('#name').css('border-color', 'lightgrey');
        }
        else
            $('#authorId').css('border-color', 'Red'); 
    }
    else {
        $('#authorId').css('border-color', 'lightgrey');
    }  
    if ($('#price').val().trim() == "") {
        $('#price').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#price').css('border-color', 'lightgrey');
    }
    return isValid;
}
var cache = '';
function FormAuthor() {
    cache = $('#myModal').html();
    $('.modal-title').html("New Author");
    $('#btnSave').removeClass('hide');
    var form = "<div class='form-group'>" +
        //"<div > <label>Id</label><input type='text' id='id' class='form-control'/>" + "</div>" +
        "<div > <label>Name</label><input type='name' id='name' class='form-control'/>" + "</div>" +
        "</div>";
    $('.modal-body').html(form);
    $('#myModal').modal('show');
    $("#btnSave").click(function () {
        if (ValidateAuthor() == false)
            return false;
        else
            AddAuthor();
            $('#myModal').html(cache);    
    });
}
function AddAuthor() {
    var author = {  
        id:1,
        name: $('#name').val(),
    };
    $.ajax({
        type: "POST",
        url: "/api/authors",
        data: JSON.stringify(author),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            ModalForm();
        },
        failure: function (result) {
            alert(result.responseText());
        },
        error: function () {
            alert();
        }
    });
}
function ValidateAuthor() {
    var isValid = true;
    if ($('#name').val().trim() == "") {
        $('#name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#name').css('border-color', 'lightgrey');
    }
    return isValid;
}
