import React from 'react';
import Head from 'next/head';
import HeaderDefault from '~/components/shared/headers/HeaderDefault';
import HeaderMobile from '~/components/shared/headers/HeaderMobile';
import FooterFullwidth from '~/components/shared/footers/FooterFullwidth';

const initHeaders = (
    <>
        <HeaderDefault />
        <HeaderMobile />
    </>
);
const initFooters = (
    <>
        <FooterFullwidth />
    </>
);

const PageContainer = ({
    header = initHeaders,
    footer = initFooters,
    children,
    title = 'Page',
}) => {
    let titleView;

    if (title !== '') {
        titleView = 'Novatic' + ' | ' + title;
    } else {
        titleView = 'Novatic' + ' | ' + process.env.titleDescription;
    }

    return (
        <>
            <Head>
                <title>{titleView}</title>
            </Head>
            {header}
            {children}
            {footer}
        </>
    );
};

export default PageContainer;
