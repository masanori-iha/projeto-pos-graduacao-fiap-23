﻿export class UserRegisterService {

     static UploadUserImage(image, userImageId, userId) {
         let formData = new FormData();
         formData.append('userImageId', userImageId);
         formData.append('files', image);
         formData.append('userId', userId);

         return $.ajax({
             url: "UploadUserImage",
             type: 'POST',
             data: formData,
             processData: false,
             contentType: false,
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 return err;
             }
         });
     }

     static GetAll() {
         return $.ajax({
             url: "GetAll",
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

     static GetUserDetails(id) {
         return $.ajax({
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
         return $.ajax({
             url: "Update",
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

     static Update(userUpdate) {
         return $.ajax({
             url: "Update",
             type: 'PUT',
             contentType: 'application/json; charset=UTF-8',
             data: JSON.stringify(userUpdate),
             success: function (response) {
                 return response;
             },
             error: function (err) {
                 return err;
             }
         });
     }

     static DeleteUser(id) {
         return $.ajax({
             url: "Delete",
             type: 'DELETE',
             data: { id },
             success: function (response) {
                 $('.container-user-list').html(response);

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

     static RemoveUserImage(userId, imageId, imageName) {
         return $.ajax({
             url: "RemoveUserImage",
             type: 'DELETE',
             data: { userId, imageId, imageName },
             success: function (response) {

                 console.log('ok: ', response);
                 return response;
             },
             error: function (err) {

                 console.log('not ok: ', response);
                 return err;
             }
         });
     }
}