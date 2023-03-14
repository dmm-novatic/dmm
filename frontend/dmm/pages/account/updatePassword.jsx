import React, { useEffect, useState } from 'react';
import BreadCrumb from '~/components/elements/BreadCrumb';
import PageContainer from '~/components/layouts/PageContainer';
import FooterDefault from '~/components/shared/footers/FooterDefault';
import Newletters from '~/components/partials/commons/Newletters';
import UpdatePassword from '~/components/partials/account/UpdatePassword';
const updatePassword = ({}) => {
    const [account, setAccount] = useState(null);
    useEffect(() => {
        if (account === null) {
            const userInfo = JSON.parse(localStorage.getItem('account'));
            setAccount(userInfo);
        }
    });
    const breadCrumb = [
        {
            text: 'Home',
            url: '/',
        },
        {
            text: 'Update Password',
        },
    ];
    return (
        <PageContainer footer={<FooterDefault />} title="Order History">
            <div className="ps-page--my-account">
                <BreadCrumb breacrumb={breadCrumb} />
                <UpdatePassword />
            </div>
            <Newletters layout="container" />
        </PageContainer>
    );
};
export default updatePassword;
