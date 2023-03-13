import React from 'react';
import WidgetProductFeatures from '~/components/shared/widgets/WidgetProductFeatures';
import WidgetSaleOnSite from '~/components/shared/widgets/WidgetSaleOnSite';
import WidgetProductSameBrands from '~/components/shared/widgets/WidgetProductSameBrands';
import WidgetShopAds from '~/components/shared/widgets/WidgetShopAds';
import { useState } from 'react';
import { useEffect } from 'react';

const ProductWidgets = () => {
    const [userInfo, setUserInfo] = useState(null);
    useEffect(() => {
        if(userInfo===null){
        const userInfo = JSON.parse(localStorage.getItem('account'));
        setUserInfo(userInfo);
        }
    });
    return (
        <section>
            <WidgetProductFeatures />
            {userInfo===null && <WidgetSaleOnSite />}
            <WidgetShopAds />
            {/* <WidgetProductSameBrands collectionSlug="shop-same-brand" /> */}
        </section>
    );
};

export default ProductWidgets;
