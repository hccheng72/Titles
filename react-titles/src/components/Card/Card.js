import React from 'react';
import { Link } from "react-router-dom";
import PropTypes from 'prop-types';
import styles from './Card.module.css';

const Card = ({item}) => (
  <Link to={{ pathname: `/details/${item.titleId}`, state: { id: item.titleId, }, }}>
    <section className="card_item">
      <div className="col-lg-12">
        <h4>{item?.titleName}</h4>
        <p className="lead"> Release Year:
          <span className="badge bg-info">{item?.releaseYear}</span>
        </p>
      </div>
    </section>
  </Link>
);

// Card.propTypes = {};

// Card.defaultProps = {};

export default Card;
