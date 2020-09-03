const colors = ['primary', 'secondary', 'success', 'warning', 'danger', 'info', 'dark']
      for (const color of colors) {
        $(`[data-toggle="popover-header-${color}"]`).popover({
          template: `
          <div class="popover popover-header-${color}" role="tooltip">
            <div class="arrow"></div>
            <h3 class="popover-header"></h3>
            <div class="popover-body"></div>
          </div>`
        })
        $(`[data-toggle="popover-${color}"]`).popover({
          template: `
          <div class="popover popover-${color}" role="tooltip">
            <div class="arrow"></div>
            <h3 class="popover-header"></h3>
            <div class="popover-body"></div>
          </div>`
        })
      }