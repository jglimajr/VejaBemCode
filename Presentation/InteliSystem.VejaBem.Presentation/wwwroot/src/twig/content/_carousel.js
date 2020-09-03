const swiperBasic = new Swiper('#swiperBasic', {
      loop: true,
      autoplay: {
        disableOnInteraction: false
      },
      slidesPerView: 1
    })
    const swiperNavigation = new Swiper('#swiperNavigation', {
      slidesPerView: 1,
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      }
    })
    const swiperNavigationSmall = new Swiper('#swiperNavigationSmall', {
      slidesPerView: 1,
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      }
    })
    const swiperNavigationAutohide = new Swiper('#swiperNavigationAutohide', {
      slidesPerView: 1,
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      }
    })
    const swiperPagination = new Swiper('#swiperPagination', {
      loop: true,
      slidesPerView: 1,
      pagination: {
        el: '.swiper-pagination',
        clickable: true
      }
    })
    const swiperPaginationFraction = new Swiper('#swiperPaginationFraction', {
      loop: true,
      slidesPerView: 1,
      pagination: {
        el: '.swiper-pagination',
        type: 'fraction',
        clickable: true
      }
    })
    const swiperPaginationProgressbar = new Swiper('#swiperPaginationProgressbar', {
      slidesPerView: 1,
      pagination: {
        el: '.swiper-pagination',
        type: 'progressbar',
        clickable: true
      }
    })
    const swiperEffectFade = new Swiper('#swiperEffectFade', {
      slidesPerView: 1,
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      },
      effect: 'fade'
    })
    const swiperEffectCoverflow = new Swiper('#swiperEffectCoverflow', {
      slidesPerView: 1,
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      },
      effect: 'coverflow'
    })
    const swiperEffectFlip = new Swiper('#swiperEffectFlip', {
      slidesPerView: 1,
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      },
      effect: 'flip'
    })
    const swiperEffectCube = new Swiper('#swiperEffectCube', {
      slidesPerView: 1,
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      },
      effect: 'cube'
    })
    const swiperVertical = new Swiper('#swiperVertical', {
      loop: true,
      direction: 'vertical',
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      },
      pagination: {
        el: '.swiper-pagination',
        clickable: true
      }
    })
    const swiperNavigationV2 = new Swiper('#swiperNavigationV2', {
      slidesPerView: 1,
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      }
    })