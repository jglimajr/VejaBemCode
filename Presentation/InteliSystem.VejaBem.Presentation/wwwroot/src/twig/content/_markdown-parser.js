autosize(document.querySelector('#markdown'))

    const md = window.markdownit({
      typographer: true,
      linkify: true
    })

    function parseMarkdown(src, dst) {
      dst.innerHTML = md.render(src)
    }
    document.querySelector('#markdown').addEventListener('keyup', function (e) {
      parseMarkdown(this.value, document.querySelector('#markdown-result'))
    })
    document.querySelector('#markdown').dispatchEvent(new Event('keyup'))