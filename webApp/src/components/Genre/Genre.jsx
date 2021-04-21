import React, { useState } from "react";
import Typography from '@material-ui/core/Typography';
import useStyles from "./Genre.styles"
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';



const Genre = props => {
    const classes = useStyles()
    const [selectedGenre, setSelectedGenre] = useState(null);
    
    const [newGenre, setNewGenre] = useState({
        name: "",
        image: "",
        description: "",
    });

    const ShowInfo = () => {
        console.log(selectedGenre)
        return (
            <div>
                <img src={selectedGenre.image}></img>
                <div>
                    {selectedGenre.name}
                </div>
                <div>
                    {selectedGenre.description}
                </div>
                Ну там онСабміт на самом деле
                <Button >
                    Сохр
               </Button>
            </div>

        )

    }
    return (
        <div>
            {selectedGenre ?
                (<ShowInfo />)
                : (
                    <div><Button variant="outlined" color="primary" className={classes.buttonCreate} onClick={() => { setSelectedGenre(newGenre) }}>
                        Додати
                         </Button>

                        {props.genres.map(g => {
                            return <Grid container spacing={3} key={g.id} className={classes.root}>
                                <Grid item xs={12} sm={10} >
                                    <Paper className={classes.paper}>{g.name} </Paper>
                                </Grid>
                                <Grid item xs={12} sm={2} >
                                    <Button variant="outlined" color="primary" className={classes.buttonEdit} onClick={() => { setSelectedGenre(g) }}>
                                        Змінити
                                    </Button>
                                </Grid>
                            </Grid>
                        })}
                    </div>
                )

            }
        </div>
    );
}
export default Genre;