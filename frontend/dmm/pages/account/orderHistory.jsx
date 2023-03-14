import React from 'react';

import BreadCrumb from '~/components/elements/BreadCrumb';
import OrderHistory from '~/components/partials/account/OrderHistory';
import PageContainer from '~/components/layouts/PageContainer';
import FooterDefault from '~/components/shared/footers/FooterDefault';
import Newletters from '~/components/partials/commons/Newletters';

const RecentViewedProductsPage = () => {
    const breadCrumb = [
        {
            text: 'Home',
            url: '/',
        },
        {
            text: 'Order History',
        },
    ];
    return (
        <>
            <PageContainer
                footer={<FooterDefault />}
                title="Order History">
                <div className="ps-page--my-account">
                    <BreadCrumb breacrumb={breadCrumb} />
                    <OrderHistory />
                </div>
                <Newletters layout="container" />
            </PageContainer>
        </>
    );
};

export default RecentViewedProductsPage;
