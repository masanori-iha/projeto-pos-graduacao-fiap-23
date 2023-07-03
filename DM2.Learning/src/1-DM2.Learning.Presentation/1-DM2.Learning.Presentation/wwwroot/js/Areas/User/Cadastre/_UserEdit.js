import { UserRegisterService } from './Services/UserRegisterService.js';
import { UserUpdate } from './Models/UserUpdate.js';

$('.btn-update').on('click', function () {

    let Id = $('#Id').val();
    let Name = $('#Name').val();
    let Age = $('#Age').val();
    let userUpdate = new UserUpdate(Id, Name, Age);

    UserRegisterService.Update(userUpdate)
        .then(function (response) {
            $('.history-back').click();

            $('.container-user-list').html(response);
            $('.container-user-list').show(500);
            $('.container-user').hide(500);

            $('.container-user-image').show(500);
        })
        .catch(function (err) {
            console.log('err: ', err.responseText);
        })
});


$('.user-file').on('change', function () {
    let userImage = document.getElementById("imgImage").files[0];
    let userImageId = $(this).data('image-id');
    let userId = $(this).data('user-id');

    UserRegisterService.UploadUserImage(userImage, userImageId, userId)
        .then(function (response) {
            $('.partial-user').html(response);

            UserRegisterService.GetUserEdit(userId)
                .then(function (response) {
                    $('.partial-user').html(response);
                })
                .catch(function (err) {
                    $('.container-user').hide(500);
                })

        })
        .catch(function (error) {
            console.log(error);
        })
});

$('.btn-delete-user-image').on('click', function () {
    let imageId = $(this).data('userImage-id');
    let imageName = $(this).data('userImage-name');
    let userId = $(this).data('user-id');

    UserRegisterService.RemoveUserImage(userId, imageId, imageName)
        .then(function (response) {
            $('.partial-user').html(response);
        })
        .catch(function (err) {
            console.log('err: ', err.responseText);
        })
})


$('.history-back').on('click', function () {
    $('.container-user-list').show(500);

    $('.container-user').hide(500);
});