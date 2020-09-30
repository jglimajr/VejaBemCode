const Calendar  = FullCalendar.Calendar
    const Draggable = FullCalendarInteraction.Draggable

    const containerEl = document.querySelector('#externalEvents')
    const calendarEl  = document.querySelector('#calendar')
    const checkbox    = document.querySelector('#removeAfterDrop')

    // initialize the external events
    new Draggable(containerEl, {
      itemSelector: '.fc-event',
      eventData: el => {
        return {
          title           : el.innerText,
          backgroundColor : window.getComputedStyle(el).getPropertyValue('background-color'),
          borderColor     : window.getComputedStyle(el).getPropertyValue('background-color'),
          textColor       : window.getComputedStyle(el).getPropertyValue('color'),
        }
      }
    })

    //Date for the calendar events (dummy data)
    const date = new Date()
    const d    = date.getDate(),
          m    = date.getMonth(),
          y    = date.getFullYear()

    // initialize the calendar
    const calendar = new Calendar(calendarEl, {
      plugins: [ 'interaction', 'dayGrid', 'timeGrid', 'list', 'bootstrap' ],
      header: {
        left   : 'prev,next today',
        center : 'title',
        right  : 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
      },
      themeSystem: 'bootstrap',
      bootstrapFontAwesome: false,
      buttonText: {
        prev  : 'Prev',
        next  : 'Next',
        today : 'Today',
        month : 'Month',
        week  : 'Week',
        day   : 'Day',
        list  : 'List'
      },
      eventLimit: true, // allow "more" link when too many events
      editable: true,
      droppable: true, // this allows things to be dropped onto the calendar
      drop: info => {
        // is the "remove after drop" checkbox checked?
        if (checkbox.checked) {
          // if so, remove the element from the "Draggable Events" list
          info.draggedEl.parentNode.removeChild(info.draggedEl)
        }
      },
      //Random default events
      events : [
        {
          title           : 'All Day Event',
          start           : new Date(y, m, 1),
          backgroundColor : red,
          borderColor     : red
        },
        {
          title           : 'Long Event',
          start           : new Date(y, m, d - 5),
          end             : new Date(y, m, d - 2),
          backgroundColor : yellow,
          borderColor     : yellow,
          textColor       : '#495057'
        },
        {
          title           : 'Meeting',
          start           : new Date(y, m, d, 10, 30),
          allDay          : false,
          backgroundColor : blue,
          borderColor     : blue
        },
        {
          title           : 'Lunch',
          start           : new Date(y, m, d, 12, 0),
          end             : new Date(y, m, d, 14, 0),
          allDay          : false,
          backgroundColor : cyan,
          borderColor     : cyan
        },
        {
          title           : 'Birthday Party',
          start           : new Date(y, m, d + 1, 19, 0),
          end             : new Date(y, m, d + 1, 22, 30),
          allDay          : false,
          backgroundColor : green,
          borderColor     : green
        },
        {
          title           : 'Click for Google',
          start           : new Date(y, m, 28),
          end             : new Date(y, m, 29),
          url             : 'http://google.com/',
          backgroundColor : blue,
          borderColor     : blue
        }
      ],
    })

    calendar.render()

    // Create event
    document.querySelector('#createEvent').addEventListener('submit', function (e) {
      if (this.checkValidity()) {
        const color = this.querySelector('input[type="radio"]:checked').value
        const value = this.querySelector('input[type="text"]').value
        document.querySelector('#externalEvents .list-group')
          .insertAdjacentHTML('afterbegin', `<li class="list-group-item fc-event bg-${color}">${value}</li>`)
        this.classList.remove('was-validated')
        this.reset()
      } else {
        this.classList.add('was-validated')
      }
      e.preventDefault()
      e.stopPropagation()
    })