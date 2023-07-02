import { UserRegisterService } from './Services/UserRegisterService.js';
import { User } from './Models/User.js';

UserRegisterService.GetAll()
    .then(function (response) {
        $('.container-user-list').html(response);
    });

$('.user-file').on('change', function (img) {

    let imgFiles = img.currentTarget.files;

    if (imgFiles && imgFiles[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            imagem.src = e.target.result;
        };
    }
});


$('.register-user').on('click', function () {
    let user = new User($('.Name').eq(0).val(),
        $('.Age').eq(0).val());

    UserRegisterService.Register(user)
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        })
});


$('.user-file').on('change', function () {
    let userImage_name = document.getElementById("imgImage").files[0];

    UserRegisterService.UploadUserImage(userImage_name)
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        })
});


