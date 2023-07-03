import { UserRegisterService } from './Services/UserRegisterService.js';
import { User } from './Models/User.js';

$('.btn-create').on('click', function () {
    let Name = $('#Name').val();
    let Age = $('#Age').val();
    let user = new User(Name, Age);

    UserRegisterService.Create(user)
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
