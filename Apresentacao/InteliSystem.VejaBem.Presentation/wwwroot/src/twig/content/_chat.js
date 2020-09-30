// scroll to bottom
    let conversationBody = document.querySelector('.inner-main-body')
    conversationBody.scrollTop = conversationBody.scrollHeight - conversationBody.clientHeight

    // Chat attachment
    document.querySelector('.chat-form input[type="file"]').addEventListener('change', function () {
      const fileLength = this.files.length
      const filename = fileLength ? (fileLength > 1 ? `${fileLength} files` : '1 file') : '<i class="material-icons">attachment</i>'
      this.parentElement.querySelector('span').innerHTML = filename
    })

    // autosize textarea
    autosize(document.querySelectorAll('textarea.autosize'))
