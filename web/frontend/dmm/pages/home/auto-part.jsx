import React from 'react';
import AutopartBanner from '~/components/partials/homepage/autopart/AutopartBanner';
import AutopartPromotions from '~/components/partials/homepage/autopart/AutopartPromotions';
import AutopartPromotions2 from '~/components/partials/homepage/autopart/AutopartPromotions2';
import AutopartRecommendForYou from '~/components/partials/homepage/autopart/AutopartRecommendForYou';
import ClientSay from '~/components/partials/commons/ClientSay';
import AutopartBestSaleBrand from '~/components/partials/homepage/autopart/AutopartBestSaleBrand';
import ProductGroupDealHot from '~/components/partials/product/ProductGroupDealHot';
import PageContainer from '~/components/layouts/PageContainer';
import SiteFeatures from '~/components/partials/homepage/autopart/SiteFeatures';
import FooterSecond from '~/components/shared/footers/FooterSecond';
import HeaderDefault from '~/components/shared/headers/HeaderDefault';
import HeaderMobile from '~/components/shared/headers/HeaderMobile';
import { useRouter } from 'next/router';
import BreadCrumb from '~/components/elements/BreadCrumb';

const HomeAutopartPage = () => {
    const headers = (
        <>
            <HeaderDefault isShop={true} />
            <HeaderMobile />
        </>
    );
    const breadCrumb = [
        {
            text: 'Home',
            url: '/',
        },
        {
            text: 'Shop',
        },
    ];
    const Router = useRouter();
    const shopId = Router.query.shopId;
    return (
        <PageContainer
            header={headers}
            footer={<FooterSecond classes="autopart" />}>
            <main
                id="homepage-2"
                style={{
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}>
                <BreadCrumb breacrumb={breadCrumb} layout="fullwidth" />
                <AutopartPromotions />
                <AutopartRecommendForYou
                    shopId={shopId}
                    collectionSlug="autopart-recommend-products"
                />
                <AutopartPromotions2 />
                <SiteFeatures />
            </main>
        </PageContainer>
    );
};

export default HomeAutopartPage;
