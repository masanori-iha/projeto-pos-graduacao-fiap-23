import { UserRegisterService } from './Services/UserRegisterService.js';
import { UserUpdate } from './Models/UserUpdate.js';

$('.btn-update').on('click', function () {

    let Id = $('#Id').val();
    let Name = $('#Name').val();
    let Age = $('#Age').val();
    let userUpdate = new UserUpdate(Id, Name, Age);

    console.log('user .btn-update: ', userUpdate);

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

$('.history-back').on('click', function () {
    $('.container-user-list').show(500);

    $('.container-user').hide(500);
});