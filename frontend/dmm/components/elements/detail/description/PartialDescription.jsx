import React from 'react';
const PartialDescription = (product) => {
    return (
        <div className="ps-document" >
            {/* <div dangerouslySetInnerHTML={{ __html: product.product.info }}></div>  */}
            <img
                src={product.product.photo}
                alt={product.product.photo}
                style={{ maxWidth: '150px' }}
            />
            <span>{product.product.description}</span>
        </div>
    );
};

export default PartialDescription;
