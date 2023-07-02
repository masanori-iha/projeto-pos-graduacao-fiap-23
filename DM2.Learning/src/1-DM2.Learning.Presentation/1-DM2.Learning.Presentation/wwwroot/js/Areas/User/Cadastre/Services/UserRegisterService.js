﻿export class UserRegisterService {

     static Register(_user) {
         return $.ajax({
             url: "RegisterNewUser",
             type: 'POST',
             contentType: 'application/json; charset=UTF-8',
             data: JSON.stringify(_user),
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 return err;
             }
         });
     }

     static UploadUserImage(image) {
         let formData = new FormData();
         formData.append('files', image);

         return $.ajax({
             url: "UploadUserImage",
             type: 'POST',
             data: formData,
             dataType: 'json',
             processData: false,
             contentType: false,
             data: formData,
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 return err;
             }
         });
     }

     static GetAll() {
         $.ajax({
             url: "GetAll",
             type: 'GET',
             data: {},
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 console.log(err);

                 return err;
             }
         });
     }

     static GetUserDetails(id) {
         $.ajax({
             url: "GetUserDetails",
             type: 'GET',
             data: { id },
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 return err;
             }
         });
     }

     static GetUserEdit(id) {
         $.ajax({
             url: "GetUserEdit",
             type: 'GET',
             data: { id },
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 return err;
             }
         });
     }

     static DeleteUser(id) {
         $.ajax({
             url: "Delete",
             type: 'DELETE',
             data: { id },
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 return err;
             }
         });
     }

     static LoadUserCreate() {
         return $.ajax({
             url: "Create",
             type: 'GET',
             data: {},
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 return err;
             }
         });
     }

     static Create(user) {
         return $.ajax({
             url: "Create",
             type: 'POST',
             contentType: 'application/json; charset=UTF-8',
             data: JSON.stringify(user),
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 return err;
             }
         });
     }
}