import React from 'react';
import BreadCrumb from '~/components/elements/BreadCrumb';
import ShopItems from '~/components/partials/shop/ShopItems';
import ShopBrands from '~/components/partials/shop/ShopBrands';
import ShopBanner from '~/components/partials/shop/ShopBanner';
import WidgetShopCategories from '~/components/shared/widgets/WidgetShopCategories';
import WidgetShopBrands from '~/components/shared/widgets/WidgetShopBrands';
import WidgetShopFilterByPriceRange from '~/components/shared/widgets/WidgetShopFilterByPriceRange';
import PageContainer from '~/components/layouts/PageContainer';
import Newletters from '~/components/partials/commons/Newletters';
import { useRouter } from 'next/router';

const ShopDefaultPage = () => {
    const Router = useRouter();
    const breadCrumb = [
        {
            text: 'Home',
            url: '/',
        },
        {
            text: 'Item',
        },
    ];
    const cateId = Router.query.category;
    const brandId = Router.query.brand;
    return (
        <PageContainer title="Item">
            <div className="ps-page--shop">
                <BreadCrumb breacrumb={breadCrumb} layout="fullwidth" />
                <div className="ps-container">
                    <ShopBanner />
                    <ShopBrands />
                    <div className="ps-layout--shop">
                        <div className="ps-layout__left">
                            <WidgetShopCategories cateId={cateId && cateId} />
                            <WidgetShopBrands brandId={brandId && brandId} />
                            <WidgetShopFilterByPriceRange />
                        </div>
                        <div className="ps-layout__right">
                            <ShopItems cateId={cateId && cateId} brandId={brandId && brandId} columns={6} pageSize={5} />
                        </div>
                    </div>
                </div>
            </div>
            <Newletters />
        </PageContainer>
    );
};
export default ShopDefaultPage;
