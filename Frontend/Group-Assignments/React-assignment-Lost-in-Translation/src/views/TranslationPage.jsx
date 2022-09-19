import { useState } from 'react';
import { useNavigate } from 'react-router-dom'
import { useEffect } from 'react';
import translator from '../individualSigns'
import { useDispatch } from 'react-redux';
import { addTranslation } from '../api/LoginAPI';
import { getTranslations } from '../store/actions/translationActions';
export function TranslationPage(props) {
    useEffect(() => {
        if (props.username === "") {
            navigateTo("/")
        }
    })
    const navigateTo = useNavigate();
    const logOut = function (props) {
        navigateTo("/")
    }
    const goToProfile = function () {
        navigateTo("/Profile/")
    }
    const dispatch = useDispatch();
    let [textInputField, setInputValue] = useState("");
    let [translationHTML, setTranslationHTML] = useState([])
    const translateInput = () => {
        let word = textInputField;
        let wordArr = "";

        for (let i = 0; i < word.length; i++) {
            if (word[i].toLowerCase() !== word[i].toUpperCase()) {
                wordArr += word[i].toLowerCase();
            }
        }


        let htmlArr = [];
        for (let i = 0; i < wordArr.length; i++) {
            htmlArr.push((
                <img src={translator(wordArr[i])} alt={wordArr[i]} key={i} />
            ))
        }
        setTranslationHTML(htmlArr)

        save(textInputField);
    }
    const save = (text) => {
        addTranslation(props.username, text,
            () => dispatch(getTranslations(props.username, props.setTranslations)));
    }

    return (
        <>
            <h2>Translations</h2>
            <label>Write in the word you want to translate</label>
            <br />
            <input type="text" onChange={(event) => setInputValue(event.target.value)} />
            <button onClick={translateInput}>
                Translate
            </button>
            <br />
            <label>The word you translated is this in american sign language</label>
            <br />
            <div id="translationWindow">{translationHTML}</div>
            <br />
            <button onClick={logOut}>
                Sign out
            </button>
            <button onClick={goToProfile}>
                Profile
            </button>
        </>
    )
}