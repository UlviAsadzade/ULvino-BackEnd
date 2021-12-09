"use strict";
exports.__esModule = true;
var jquery_1 = require("jquery");
var dom_1 = require("../core/dom");
var range_1 = require("../core/range");
var Bullet_1 = require("../editing/Bullet");
/**
 * @class editing.Typing
 *
 * Typing
 *
 */
var Typing = /** @class */ (function () {
    function Typing() {
        // a Bullet instance to toggle lists off
        this.bullet = new Bullet_1["default"]();
    }
    /**
     * insert tab
     *
     * @param {WrappedRange} rng
     * @param {Number} tabsize
     */
    Typing.prototype.insertTab = function (rng, tabsize) {
        var tab = dom_1["default"].createText(new Array(tabsize + 1).join(dom_1["default"].NBSP_CHAR));
        rng = rng.deleteContents();
        rng.insertNode(tab, true);
        rng = range_1["default"].create(tab, tabsize);
        rng.select();
    };
    /**
     * insert paragraph
     */
    Typing.prototype.insertParagraph = function (editable) {
        var rng = range_1["default"].create(editable);
        // deleteContents on range.
        rng = rng.deleteContents();
        // Wrap range if it needs to be wrapped by paragraph
        rng = rng.wrapBodyInlineWithPara();
        // finding paragraph
        var splitRoot = dom_1["default"].ancestor(rng.sc, dom_1["default"].isPara);
        var nextPara;
        // on paragraph: split paragraph
        if (splitRoot) {
            // if it is an empty line with li
            if (dom_1["default"].isEmpty(splitRoot) && dom_1["default"].isLi(splitRoot)) {
                // toogle UL/OL and escape
                this.bullet.toggleList(splitRoot.parentNode.nodeName);
                return;
                // if it is an empty line with para on blockquote
            }
            else if (dom_1["default"].isEmpty(splitRoot) && dom_1["default"].isPara(splitRoot) && dom_1["default"].isBlockquote(splitRoot.parentNode)) {
                // escape blockquote
                dom_1["default"].insertAfter(splitRoot, splitRoot.parentNode);
                nextPara = splitRoot;
                // if new line has content (not a line break)
            }
            else {
                nextPara = dom_1["default"].splitTree(splitRoot, rng.getStartPoint());
                var emptyAnchors = dom_1["default"].listDescendant(splitRoot, dom_1["default"].isEmptyAnchor);
                emptyAnchors = emptyAnchors.concat(dom_1["default"].listDescendant(nextPara, dom_1["default"].isEmptyAnchor));
                jquery_1["default"].each(emptyAnchors, function (idx, anchor) {
                    dom_1["default"].remove(anchor);
                });
                // replace empty heading, pre or custom-made styleTag with P tag
                if ((dom_1["default"].isHeading(nextPara) || dom_1["default"].isPre(nextPara) || dom_1["default"].isCustomStyleTag(nextPara)) && dom_1["default"].isEmpty(nextPara)) {
                    nextPara = dom_1["default"].replace(nextPara, 'p');
                }
            }
            // no paragraph: insert empty paragraph
        }
        else {
            var next = rng.sc.childNodes[rng.so];
            nextPara = jquery_1["default"](dom_1["default"].emptyPara)[0];
            if (next) {
                rng.sc.insertBefore(nextPara, next);
            }
            else {
                rng.sc.appendChild(nextPara);
            }
        }
        range_1["default"].create(nextPara, 0).normalize().select().scrollIntoView(editable);
    };
    return Typing;
}());
exports["default"] = Typing;
//# sourceMappingURL=Typing.js.map