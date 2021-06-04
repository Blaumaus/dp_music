import React, { useState } from "react";
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Typography from '@material-ui/core/Typography';
import useStyles from "./EntityCard.styles"
import ShowDetails from 'components/ShowDetails/ShowDetails';

export default function MediaCard(props) {
  const classes = useStyles();

  return (
    <div>
      <Card className={classes.mediaCardContainer}>
        <CardActionArea
          onClick={props.onClick}
          id={props.id}
        >
          <CardMedia
            className={classes.mediaCardContainer}
            className={classes.media}
            image={props.image}
            style={{ width: 'auto', height: '13em', objectFit: 'contain' }}
          />
          <CardContent>
            <Typography gutterBottom variant="h6" component="h2" align="center" color="primary">
              {props.name}
            </Typography>
          </CardContent>
        </CardActionArea>
        <ShowDetails
          name={props.name}
          description={props.description}
          foundationDate={props.foundationDate}
          countryCode={props.countryCode} />
      </Card>
    </div>

  );
}