import React, { useState } from "react";
import useStyles from "./Select.styles"
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Typography from '@material-ui/core/Typography';
import { Link } from 'react-router-dom';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import ArrowForwardIosIcon from '@material-ui/icons/ArrowForwardIos';

const Select = props => {

    const classes = useStyles()

    const { handleAllCompositionClick, handleAlbumClick, buttonsback } = props

    return (
        <CssBaseline>
            <div className={classes.buttonsBackContainer}>
                <Breadcrumbs separator={<ArrowForwardIosIcon fontSize="small" />}>
                    {buttonsback.map(button => {
                        return <Button component={Link} to={button.link}>
                            {button.name}
                        </Button>
                    })}
                </Breadcrumbs>
            </div>
            <div className={classes.paper} align="center">
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12}>
                        <span className={classes.modeChoiceText}>Виберіть Далі</span>
                    </Grid>

                    <Grid item xs={12} sm={6}>
                        <Card className={classes.mediaCardContainer}>
                            <CardActionArea
                                onClick={handleAllCompositionClick}

                            >
                                <CardMedia
                                    className={classes.mediaCardContainer}
                                    className={classes.media}
                                    image='https://image.freepik.com/free-vector/treble-clef-and-notes-neon-sign_1262-15752.jpg'
                                />
                                <CardContent>
                                    <Typography gutterBottom variant="h6" component="h2" align="center" color="primary">
                                        Всі композиції
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                        </Card>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Card className={classes.mediaCardContainer}>
                            <CardActionArea
                                onClick={handleAlbumClick}

                            >
                                <CardMedia
                                    className={classes.mediaCardContainer}
                                    className={classes.media}
                                    image='https://image.freepik.com/free-vector/music-player-neon-sign_1262-15625.jpg'
                                />
                                <CardContent>
                                    <Typography gutterBottom variant="h6" component="h2" align="center" color="primary">
                                        Альбоми
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                        </Card>
                    </Grid>
                </Grid>
            </div>

        </CssBaseline>

    )
}
export default Select;