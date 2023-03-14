import React from 'react';
import SiteFeatures from '~/components/partials/homepage/home-default/SiteFeatures';
import HomeAdsColumns from '~/components/partials/homepage/home-default/HomeAdsColumns';
import HomeAds from '~/components/partials/homepage/home-default/HomeAds';
import DownLoadApp from '~/components/partials/commons/DownLoadApp';
import NewArrivals from '~/components/partials/homepage/home-default/NewArrivals';
import Newletters from '~/components/partials/commons/Newletters';
import HomeDefaultDealOfDay from '~/components/partials/homepage/home-default/HomeDefaultDealOfDay';
import HomeDefaultTopCategories from '~/components/partials/homepage/home-default/HomeDefaultTopCategories';
import HomeDefaultProductListing from '~/components/partials/homepage/home-default/HomeDefaultProductListing';
import HomeDefaultBanner from '~/components/partials/homepage/home-default/HomeDefaultBanner';
import PageContainer from '~/components/layouts/PageContainer';

const HomepageDefaultPage = () => {
    return (
        <PageContainer title="Decentralized Metaverse Mall">
            <main id="homepage-1">
                <HomeDefaultBanner />
                <SiteFeatures />
                <HomeDefaultDealOfDay />
                <HomeAdsColumns />
                {/* <HomeDefaultTopCategories /> */}
                <HomeDefaultProductListing
                    collectionSlug="Smart phone"
                    title="Smart Phone"
                    idRender={1000001}
                />
                <HomeDefaultProductListing
                    collectionSlug="Lap-Top"
                    title="Laptop"
                    idRender={1000005}
                />
                <HomeDefaultProductListing
                    collectionSlug="consumer-electronics"
                    title="consumer electronics"
                    idRender={1000004}
                />
                <HomeAds />
                <DownLoadApp />
                {/* <NewArrivals collectionSlug="new-arrivals-products" /> */}
                <Newletters />
            </main>
        </PageContainer>
    );
};

export default HomepageDefaultPage;
