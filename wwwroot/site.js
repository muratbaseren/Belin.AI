function blurActiveElement() {
    document.activeElement?.blur();
}

function focusElement(selector) {
    setTimeout(() => document.querySelector(selector)?.focus(), 100);
}

function setScrollToBottom(selector) {
    setTimeout(() => {
        const el = document.querySelector(selector);
        if (el) {
            el.scrollTop = el.scrollHeight;
        }
    }, 100);
}

window.beautifyHtml = function (code, options) {
    return html_beautify(code, options || {});
}

window.removeClass = function (selector, className) {
    const elements = document.querySelectorAll(selector);
    elements.forEach(el => el.classList.remove(className));
}

window.setAppAndUserName = function (appName, username) {
    document.getElementById('app-user-name').innerHTML = `${username} | ${appName}`;
}