// Chart options
    const options = {
      maintainAspectRatio: false // disable the maintain aspect ratio in options then it uses the available height
    }

    /***************** DOUGHNUT BASIC *****************/
    new Chart('doughnut-basic', {
      type: 'doughnut',
      data: {
        labels: ['Red', 'Blue', 'Yellow'],
        datasets: [{
          data: [300, 50, 100],
          backgroundColor: [red, blue, yellow]
        }]
      },
      options: options
    })

    /***************** DOUGHNUT MULTI *****************/
    new Chart('doughnut-multi', {
      type: 'doughnut',
      data: {
        labels: ['Red', 'Blue', 'Yellow'],
        datasets: [
          {
            data: [100, 300, 50],
            backgroundColor: [red, blue, yellow]
          },
          {
            data: [300, 50, 100],
            backgroundColor: [red, blue, yellow]
          }
        ]
      },
      options: options
    })

    /***************** PIE BASIC *****************/
    new Chart('pie-basic', {
      type: 'pie',
      data: {
        labels: ['Red', 'Blue', 'Yellow'],
        datasets: [{
          data: [300, 50, 100],
          backgroundColor: [red, blue, yellow]
        }]
      },
      options: options
    })

    /***************** PIE MULTI *****************/
    new Chart('pie-multi', {
      type: 'pie',
      data: {
        labels: ['Red', 'Blue', 'Yellow'],
        datasets: [
          {
            data: [100, 300, 50],
            backgroundColor: [red, blue, yellow]
          },
          {
            data: [300, 50, 100],
            backgroundColor: [red, blue, yellow]
          }
        ]
      },
      options: options
    })

    /***************** DOUGHNUT SEMI CIRCLE *****************/
    let doughnutSemi = new Chart('doughnut-semi', {
      type: 'doughnut',
      data: {
        labels: ['Red', 'Blue', 'Yellow'],
        datasets: [
          {
            data: [100, 300, 50],
            backgroundColor: [red, blue, yellow]
          },
          {
            data: [300, 50, 100],
            backgroundColor: [red, blue, yellow]
          }
        ]
      },
      options: options
    })
    doughnutSemi.options.circumference = Math.PI
    doughnutSemi.options.rotation = -Math.PI
    doughnutSemi.update()

    /***************** PIE SEMI CIRCLE *****************/
    let pieSemi = new Chart('pie-semi', {
      type: 'pie',
      data: {
        labels: ['Red', 'Blue', 'Yellow'],
        datasets: [
          {
            data: [100, 300, 50],
            backgroundColor: [red, blue, yellow]
          },
          {
            data: [300, 50, 100],
            backgroundColor: [red, blue, yellow]
          }
        ]
      },
      options: options
    })
    pieSemi.options.circumference = Math.PI
    pieSemi.options.rotation = -Math.PI
    pieSemi.update()

    /***************** POLAR CHART *****************/
    let polarChart = new Chart.PolarArea('polar-chart', {
      data: {
        labels: ['Red', 'Blue', 'Yellow'],
        datasets: [{
          data: [200, 50, 100],
          backgroundColor: [
            Chart.helpers.color(red).alpha(0.8).rgbString(),
            Chart.helpers.color(blue).alpha(0.8).rgbString(),
            Chart.helpers.color(yellow).alpha(0.8).rgbString(),
          ]
        }]
      },
      options: options,
      options: {
        maintainAspectRatio: false,
        legend: {
          position: 'top'
        },
        title: {
          display: true,
          text: ''
        }
      }
    })
    polarChart.options.legend.position = 'top'
    polarChart.options.title.display = true
    polarChart.options.title.text = ''
    polarChart.update()