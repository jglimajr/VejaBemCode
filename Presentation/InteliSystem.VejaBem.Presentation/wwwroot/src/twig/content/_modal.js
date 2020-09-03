const loremIpsum = 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.'

    bootbox.setDefaults({
      closeButton: false
    })

    /***************** BOOTBOX ALERT *****************/
    document.getElementById('alertBasic').addEventListener('click', () => {
      bootbox.alert(loremIpsum)
    })
    document.getElementById('alertCallback').addEventListener('click', () => {
      bootbox.alert(loremIpsum, () => {
        alert('This is the callback')
      })
    })
    document.getElementById('alertSmall').addEventListener('click', () => {
      bootbox.alert({
        message: loremIpsum,
        size: 'sm'
      })
    })
    document.getElementById('alertLarge').addEventListener('click', () => {
      bootbox.alert({
        message: loremIpsum,
        size: 'lg'
      })
    })
    document.getElementById('alertExtraLarge').addEventListener('click', () => {
      bootbox.alert({
        message: loremIpsum,
        size: 'xl'
      })
    })

    /***************** BOOTBOX CONFIRM *****************/
    document.getElementById('confirmBasic').addEventListener('click', () => {
      bootbox.confirm('This is the default confirm!', result => {
        alert(`The callback is: ${result}`)
      })
    })
    document.getElementById('confirmCustom').addEventListener('click', () => {
      bootbox.confirm({
        message: 'Are you sure want to remove this data ?',
        buttons: {
          confirm: {
            label: 'Yes, I am sure',
            className: 'btn-danger'
          },
          cancel: {
            label: 'No, Keep the data',
            className: 'btn'
          }
        },
        callback: result => {
          if (result) {
            alert('Your data has been removed!')
          }
        }
      })
    })
    document.getElementById('confirmIcon').addEventListener('click', () => {
      const confirmRemove = bootbox.confirm({
        message: `<h3 class="d-flex align-items-center">
                    <i class="material-icons text-danger h2 mr-2 mb-0">warning</i>
                    Warning!
                  </h3>
                  Are you sure want to remove this data ?`,
        buttons: {
          confirm: {
            label: 'Proceed',
            className: 'btn-danger'
          }
        },
        callback: result => {
          if (result) {
            alert('Your data has been removed!')
          }
        }
      })
    })

    /***************** BOOTBOX PROMPT *****************/
    document.getElementById('promptBasic').addEventListener('click', () => {
      bootbox.prompt('What is your name ?', result => {
        if (result) {
          alert(`Hi ${result}`)
        }
      })
    })
    document.getElementById('promptCheckbox').addEventListener('click', () => {
      bootbox.prompt({
        title: "This is a prompt with a set of checkbox inputs!",
        value: ['1', '3'],
        inputType: 'checkbox',
        inputOptions: [{
          text: 'Choice One',
          value: '1',
        },
        {
          text: 'Choice Two',
          value: '2',
        },
        {
          text: 'Choice Three',
          value: '3',
        }],
        callback: result => {
          if (result) {
            alert(`You choose: ${result}`)
          }
        }
      })
    })
    document.getElementById('promptRadio').addEventListener('click', () => {
      bootbox.prompt({
        title: "This is a prompt with a set of radio inputs!",
        message: '<p>Please select an option below:</p>',
        inputType: 'radio',
        inputOptions: [{
          text: 'Choice One',
          value: '1',
        },
        {
          text: 'Choice Two',
          value: '2',
        },
        {
          text: 'Choice Three',
          value: '3',
        }],
        callback: result => {
          if (result) {
            alert(`You choose: ${result}`)
          }
        }
      })
    })
    document.getElementById('promptPassword').addEventListener('click', () => {
      bootbox.prompt({
        title: "This is a prompt with a password input!",
        inputType: 'password',
        callback: result => {
          if (result) {
            alert(`Your password is: ${result}`)
          }
        }
      })
    })
    document.getElementById('promptSelect').addEventListener('click', () => {
      bootbox.prompt({
        show: false,
        title: "This is a prompt with select!",
        inputType: 'select',
        inputOptions: [
        {
          text: 'Choose one...',
          value: '',
        },
        {
          text: 'Choice One',
          value: '1',
        },
        {
          text: 'Choice Two',
          value: '2',
        },
        {
          text: 'Choice Three',
          value: '3',
        }],
        callback: result => {
          if (result) {
            alert(`You choose: ${result}`)
          }
        }
      })
      $('.bootbox').on('show.bs.modal', function () {
        $(this).find('select').addClass('custom-select')
      }).modal('show')
    })
    document.getElementById('promptSelectMultiple').addEventListener('click', () => {
      bootbox.prompt({
        show: false,
        title: "This is a prompt with a multiple select!",
        inputType: 'select',
        multiple: true,
        value: ['1', '3'],
        inputOptions: [
        {
          text: 'Choose one...',
          value: '',
        },
        {
          text: 'Choice One',
          value: '1',
        },
        {
          text: 'Choice Two',
          value: '2',
        },
        {
          text: 'Choice Three',
          value: '3',
        }],
        callback: result => {
          if (result) {
            alert(`You choose: ${result}`)
          }
        }
      })
      $('.bootbox').on('show.bs.modal', function () {
        $(this).find('select').addClass('custom-select')
      }).modal('show')
    })
    document.getElementById('promptTextarea').addEventListener('click', () => {
      bootbox.prompt({
        title: "This is a prompt with a textarea!",
        inputType: 'textarea',
        callback: result => {
          if (result) {
            alert(`The result is: ${result}`)
          }
        }
      })
    })

    /***************** BOOTBOX CUSTOM DIALOGS *****************/
    document.getElementById('customLoading').addEventListener('click', () => {
      var dialog = bootbox.dialog({
        message: `<div class="d-flex align-items-center">
                    <div class="spinner-border spinner-border-sm mr-2"></div> Please wait while we do something...
                  </div>`
      })
      setTimeout(() => {
        dialog.modal('hide')
      }, 2000)
    })
    document.getElementById('customButtons').addEventListener('click', () => {
      bootbox.dialog({
        title: 'A custom dialog with buttons and callbacks',
        message: "<p>This dialog has buttons. Each button has it's own callback function.</p>",
        buttons: {
          cancel: {
            label: "Cancel!",
            className: 'btn-danger',
            callback: () => {
              alert('Cancel clicked')
            }
          },
          noclose: {
            label: "I don't close the modal!",
            className: 'btn-warning',
            callback: () => {
              alert('Custom button clicked')
              return false
            }
          },
          ok: {
            label: "I'm an OK button!",
            className: 'btn-info',
            callback: () => {
              alert('Custom OK clicked')
            }
          }
        }
      })
    })