﻿import { UserRegisterService } from './Services/UserRegisterService.js';

$('.btn-details').on('click', function () {
    let id = $(this).data('user-id');

    UserRegisterService.GetUserDetails(id)
        .then(function (response) {
            $('.partial-user').html(response);
            $('.container-user').show(500);

            $('.container-user-list').hide(500);
        })
        .catch(function (err) {
            $('.container-user').hide(500);
        })
})

$('.user-create-get').on('click', function () {
    UserRegisterService.LoadUserCreate()
        .then(function (response) {
            $('.container-user').html(response);
            $('.container-user-list').hide(500);
            $('.container-user').show(500);
        })
        .catch(function (err) {
            console.log('err: ', err.responseText);
        })
})

$('.btn-edit').on('click', function () {
    let id = $(this).data('user-id');

    UserRegisterService.GetUserEdit(id)
        .then(function (response) {
            $('.partial-user').html(response);
            $('.container-user').show(500);

            $('.container-user-list').hide(500);
        })
        .catch(function (err) {
            $('.container-user').hide(500);
        })

})

$('.btn-delete').on('click', function () {
    let id = $(this).data('user-id');

    UserRegisterService.DeleteUser(id)
        .then(function (response) {
            console.log('response: ', response);            
        })
        .catch(function (err) {
            console.log('error')
        })

})