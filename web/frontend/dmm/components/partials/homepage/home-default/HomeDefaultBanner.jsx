import React, { useEffect, useState } from 'react';
import Slider from 'react-slick';
import NextArrow from '~/components/elements/carousel/NextArrow';
import PrevArrow from '~/components/elements/carousel/PrevArrow';
import Link from 'next/link';
import MediaRepository from '~/repositories/MediaRepository';
import { baseUrl } from '~/repositories/Repository';
import { getItemBySlug } from '~/utilities/product-helper';
import Promotion from '~/components/elements/media/Promotion';

const HomeDefaultBanner = () => {
    const [bannerItems, setBannerItems] = useState(null);
    const [promotion1, setPromotion1] = useState(null);
    const [promotion2, setPromotion2] = useState(null);

    useEffect(async () => {
        const responseData = await MediaRepository.getPromotionsBySlug('DMM_Small_1');
        const responseData1 = await MediaRepository.getPromotionsBySlug('DMM_Small_2');
        const responseData2 = await MediaRepository.getBannersBySlug('DMM_Banner');
        if (responseData2) {
            setBannerItems(responseData2);
        }
        if (responseData) {
            setPromotion1(responseData);
        }
        if (responseData1) {
            setPromotion2(responseData1);
        }
    }, []);

    const carouselSetting = {
        dots: false,
        infinite: true,
        speed: 750,
        fade: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        nextArrow: <NextArrow />,
        prevArrow: <PrevArrow />,
    };

    // Views
    let mainCarouselView;

    if (bannerItems) {
        const carouseItems = bannerItems.map((item) => (

            <div className="slide-item" key={item.id}>
                <Link href="/shop">
                    <a
                        className="ps-banner-item--default bg--cover"
                    >
                        <img src={`${item.description}`} alt="dmm" />
                    </a>
                </Link>
            </div>
        ));
        mainCarouselView = (
            <Slider {...carouselSetting} className="ps-carousel">
                {carouseItems}
            </Slider>
        );
    }
    return (
        <div className="ps-home-banner ps-home-banner--1" >
            <div className="ps-container" >
                <div className="ps-section__left">{mainCarouselView}</div>
                <div className="ps-section__right" style={{display:"flex",flexDirection:"column",justifyContent:"space-between"}}>
                    <Promotion
                        link="/shop"
                        image={
                            promotion1 !== null
                                ? promotion1[0].description
                                : null
                        }
                    />

                    <Promotion
                        link="/shop"
                        image={
                            promotion2 !== null
                                ? promotion2[0].description
                                : null
                        }
                    />
                </div>
            </div>
        </div>
    );
};

export default HomeDefaultBanner;
