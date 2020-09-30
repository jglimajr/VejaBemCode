/***************** SIMPLE DEFAULT NOTIFICATION *****************/
      $('#notyDefault').click(function () {
        new Noty({
          text: '<h5>Hi there!</h5>This is a simple notification.',
          timeout: 2000 // 2000 miliseconds (2 seconds)
        }).show()
      })

      /***************** SIMPLE SUCCESS NOTIFICATION *****************/
      $('#notySuccess').click(function () {
        new Noty({
          type: 'success',
          text: '<h5>Hi there!</h5>This is a simple success notification.',
          timeout: 2000
        }).show()
      })

      /***************** SIMPLE INFO NOTIFICATION *****************/
      $('#notyInfo').click(function () {
        new Noty({
          type: 'info',
          text: '<h5>Hi there!</h5>This is a simple info notification.',
          timeout: 2000
        }).show()
      })

      /***************** SIMPLE WARNING NOTIFICATION *****************/
      $('#notyWarning').click(function () {
        new Noty({
          type: 'warning',
          text: '<h5>Hi there!</h5>This is a simple warning notification.',
          timeout: 2000
        }).show()
      })

      /***************** SIMPLE ERROR NOTIFICATION *****************/
      $('#notyError').click(function () {
        new Noty({
          type: 'error',
          text: '<h5>Hi there!</h5>This is a simple error notification.',
          timeout: 2000
        }).show()
      })

      /***************** TOP POSITION *****************/
      $('#notyTop').click(function () {
        new Noty({
          layout: 'top',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple top notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** TOP LEFT POSITION *****************/
      $('#notyTopLeft').click(function () {
        new Noty({
          layout: 'topLeft',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple topLeft notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** TOP CENTER POSITION *****************/
      $('#notyTopCenter').click(function () {
        new Noty({
          layout: 'topCenter',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple topCenter notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** TOP RIGHT POSITION *****************/
      // topRight is used as default layout, so you don't need to include the layout: "topRight" option
      $('#notyTopRight').click(function () {
        new Noty({
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple topRight notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** CENTER POSITION *****************/
      $('#notyCenter').click(function () {
        new Noty({
          layout: 'center',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple center notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** CENTER LEFT POSITION *****************/
      $('#notyCenterLeft').click(function () {
        new Noty({
          layout: 'centerLeft',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple centerLeft notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** CENTER RIGHT POSITION *****************/
      $('#notyCenterRight').click(function () {
        new Noty({
          layout: 'centerRight',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple centerRight notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** BOTTOM POSITION *****************/
      $('#notyBottom').click(function () {
        new Noty({
          layout: 'bottom',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple bottom notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** BOTTOM LEFT POSITION *****************/
      $('#notyBottomLeft').click(function () {
        new Noty({
          layout: 'bottomLeft',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple bottomLeft notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** BOTTOM CENTER POSITION *****************/
      $('#notyBottomCenter').click(function () {
        new Noty({
          layout: 'bottomCenter',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple bottomCenter notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** BOTTOM RIGHT POSITION *****************/
      $('#notyBottomRight').click(function () {
        new Noty({
          layout: 'bottomRight',
          text: '<div class="text-center"><h5>Hi there!</h5>This is a simple bottomRight notification.</div>',
          timeout: 2000
        }).show()
      })

      /***************** WITH ICON *****************/
      $('#notyIcon').click(function () {
        new Noty({
          type: 'success',
          text: '<div class="media">\
                  <span><i data-feather="check-circle"></i></span>\
                  <div class="media-body ml-3">\
                    <h5>Hi there!</h5>This is a success notification with icon.\
                  </div>\
                </div>',
          timeout: 2000
        }).show()
        feather.replace()
      })

      /***************** WITH MEDIA *****************/
      $('#notyMedia').click(function () {
        new Noty({
          text: '<div class="media">\
                  <img src="{{ folder.img }}user.svg" width="50" height="50" class="rounded-circle">\
                  <div class="media-body ml-3">\
                    <h5>Welcome Admin</h5>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Dolorum impedit, corporis veritatis aut ex corrupti necessitatibus eveniet sed ipsa inventore\
                  </div>\
                </div>',
          timeout: 2000
        }).show()
      })

      /***************** CONFIRM DIALOGS *****************/
      $('#notyConfirm').click(function (e) {
        new Noty({
          text: '<h5>Are you sure want to remove this data ?</h5>',
          buttons: [
            Noty.button('YES', 'btn btn-sm btn-danger rounded-0', function (n) {
              n.close() // close noty
              // YOUR ACTION HERE

              // If done, show success notification
              new Noty({
                type: 'success',
                text: 'Data successfully removed !',
                timeout: 2000
              }).show()
            }),
            Noty.button('CANCEL', 'btn btn-sm btn-light rounded-0', function (n) {
              n.close() // close noty
            })
          ]
        }).show()
      })

      /***************** STICKY *****************/
      // just remove timeout function
      $('#notySticky').click(function () {
        new Noty({
          text: '<h5>Hi there!</h5>This is a simple sticky notification. Click to remove this notification',
        }).show()
      })

      /***************** CLOSE BUTTON *****************/
      $('#notyCloseButton').click(function () {
        new Noty({
          type: 'info',
          text: '<h5>Hi there!</h5>This is a simple info notification. Close this notification by clicking the button on the top right',
          closeWith: ['button']
        }).show()
      })

      /***************** NO PROGRESSBAR *****************/
      $('#notyNoProgressBar').click(function () {
        new Noty({
          type: 'info',
          text: '<h5>Hi there!</h5>This is a simple info notification. This notification will closed in 3 seconds without progress bar',
          closeWith: ['button'],
          timeout: 3000,
          progressBar: false
        }).show()
      })

      $('#toastDefault').click(function () {
        App.toast({
          title: 'Notification',
          text: 'Welcome to <b>Mimity</b> - Responsive admin dashboard.',
        })
      })
      $('#toastSuccess').click(function () {
        App.toast({
          icon: 'success',
          title: 'Success',
          text: 'Your message has been sent successfully.',
        })
      })
      $('#toastWarning').click(function () {
        App.toast({
          icon: 'warning',
          title: 'Warning',
          text: 'There was a problem with your network connection.',
        })
      })
      $('#toastError').click(function () {
        App.toast({
          icon: 'error',
          title: 'Error',
          text: 'A problem has been occurred while submitting your data.',
        })
      })
      $('#toastTopLeft').click(function () {
        App.toast({
          position: 'top-left',
          icon: 'success',
          title: 'Success',
          text: 'Your message has been sent successfully.',
        })
      })
      $('#toastBottomRight').click(function () {
        App.toast({
          position: 'bottom-right',
          icon: 'success',
          title: 'Success',
          text: 'Your message has been sent successfully.',
        })
      })
      $('#toastBottomLeft').click(function () {
        App.toast({
          position: 'bottom-left',
          icon: 'success',
          title: 'Success',
          text: 'Your message has been sent successfully.',
        })
      })
      $('#toastSticky').click(function () {
        App.toast({
          autohide: false,
          title: 'Sticky notification',
          text: 'Welcome to <b>Mimity</b> - Responsive admin dashboard. Close this notification by clicking the button on the top right',
        })
      })
      $('#toastNoAnimation').click(function () {
        App.toast({
          animation: false,
          icon: 'success',
          title: 'Success',
          text: 'Your message has been sent successfully.',
        })
      })
      $('#toastDelay1').click(function () {
        App.toast({
          delay: 1000,
          icon: 'success',
          title: 'Success',
          text: 'Your message has been sent successfully.',
        })
      })
      $('#toastDelay2').click(function () {
        App.toast({
          icon: 'success',
          title: 'Success',
          text: 'Your message has been sent successfully.',
        })
      })
      $('#toastDelay3').click(function () {
        App.toast({
          delay: 3000,
          icon: 'success',
          title: 'Success',
          text: 'Your message has been sent successfully.',
        })
      })
